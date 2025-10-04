using AutoMapper;
using GerenciadorDeCursos.Application.Dtos.Course.Request;
using GerenciadorDeCursos.Application.Dtos.Course.Response;
using GerenciadorDeCursos.Application.Interfaces;
using GerenciadorDeCursos.Application.Shared;
using GerenciadorDeCursos.Domain.Entities.Course;
using GerenciadorDeCursos.Domain.Model.Exceptions;
using GerenciadorDeCursos.Domain.Repositories;
using GerenciadorDeCursos.Domain.Repositories.Shared;
using GerenciadorDeCursos.Infrastructure.Repositories.Interfaces;
using GerenciadorDeCursos.Shared;
using GerenciadorDeCursos.Shared.Enums;

namespace GerenciadorDeCursos.Application.UseCases
{
    public class CreateCourseUseCase
        : UseCaseBase<CreateCourseRequestDto, CourseResponseDto>, ICreateCourseUseCase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public CreateCourseUseCase(
            ICourseRepository courseRepository,
            ITeacherRepository teacherRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
            _departmentRepository = departmentRepository;
        }

        protected override async Task<Response<CourseResponseDto>> ExecutaRegraDeNegocio(CreateCourseRequestDto request)
        {
            await VerificaSeCursoJaExiste(request.Title);

            await VerificaSeProfessorEstaCadastrado(request.TeachersName);

            await VerificaSeDepartamentoEstaCadastrado(request.DepartmentsCode);

            CourseEntity cursoCriado = await CriaCurso(request);

            return MapearResponse(cursoCriado);
        }

        internal async Task VerificaSeCursoJaExiste(string title)
        {
            CourseEntity curso = await _courseRepository.GetCourseByTitleAsync(title);
            if (curso != null)
            {
                throw new BusinessException("Curso já cadastrado");
            }
        }

        internal async Task VerificaSeProfessorEstaCadastrado(string name)
        {
            _ = await _teacherRepository.GetTeacherByName(name) ??
                throw new BusinessException("Não existe professor cadastrado com o nome fornecido");
        }

        internal async Task VerificaSeDepartamentoEstaCadastrado(string code)
        {
            _ = await _departmentRepository.GetByCodeAsync(code) ??
                throw new BusinessException("Departamento não cadastrado");
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