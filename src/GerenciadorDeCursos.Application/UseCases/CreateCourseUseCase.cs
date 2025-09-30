using AutoMapper;
using GerenciadorDeCursos.Application.Dtos.Course.Request;
using GerenciadorDeCursos.Application.Dtos.Course.Response;
using GerenciadorDeCursos.Application.Interfaces;
using GerenciadorDeCursos.Application.Shared;
using GerenciadorDeCursos.Domain.Entities.Course;
using GerenciadorDeCursos.Domain.Repositories.Shared;
using GerenciadorDeCursos.Infrastructure.Repositories.Interfaces;
using GerenciadorDeCursos.Shared;
using GerenciadorDeCursos.Shared.Enums;

namespace GerenciadorDeCursos.Application.UseCases
{
    internal class CreateCourseUseCase
        : UseCaseBase<CreateCourseRequestDto, CourseResponseDto>, ICreateCourseUseCase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;

        public CreateCourseUseCase(
            ICourseRepository courseRepository,
            ITeacherRepository teacherRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }

        protected override async Task<Response<CourseResponseDto>> ExecutaRegraDeNegocio(CreateCourseRequestDto request)
        {
            await VerificaSeCursoJaExiste(request.Title);

            await VerificaSeProfessorEstaCadastrado(request.TeachersName);

            CourseEntity cursoCriado = await CriaCurso(request);

            return MapearResponse(cursoCriado);
        }

        internal async Task VerificaSeCursoJaExiste(string title)
        {
            _ = (await _courseRepository.GetCourseByTitleAsync(title)) ?? throw new ArgumentException("Curso ja cadastrado");
        }

        internal async Task VerificaSeProfessorEstaCadastrado(string name)
        {
            _ = (await _teacherRepository.GetTeacherByName(name)) ?? throw new ArgumentException("Não existe professor cadastrado com o nome fornecido");
        }

        internal async Task<CourseEntity> CriaCurso(CreateCourseRequestDto dto)
        {
            CourseEntity course = _mapper.Map<CourseEntity>(dto);

            return await _courseRepository.AddAsync(course);
        }

        internal Response<CourseResponseDto> MapearResponse(CourseEntity course)
            => new()
            {
                Result = _mapper.Map<CourseResponseDto>(course),
                Status = ResponseStatus.Created,
            };
    }
}