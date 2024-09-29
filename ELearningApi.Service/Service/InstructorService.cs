using ELearningApi.Data.Entities;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

    public class InstructorService : IInstructorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstructorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Instructor> CreateInstructorAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            if (instructor == null)
                throw new ArgumentNullException(nameof(instructor));

            await _unitOfWork.Repository<Instructor>().AddAsync(instructor, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return instructor;
        }

        public async Task<Instructor> GetInstructorByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var instructors = await _unitOfWork.Repository<Instructor>()
                .FindAsync(i => i.Id == id, include: q => q.Include(i => i.ApplicationUser), cancellationToken);
            var instructor = instructors.FirstOrDefault();

            if (instructor == null)
                throw new KeyNotFoundException($"Instructor with ID {id} not found.");

            return instructor;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync(CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Repository<Instructor>()
                .FindAsync(i => true, include: q => q.Include(i => i.ApplicationUser), cancellationToken);
        }

        public async Task<Instructor> UpdateInstructorAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            if (instructor == null)
                throw new ArgumentNullException(nameof(instructor));

            var existingInstructor = await GetInstructorByIdAsync(instructor.Id, cancellationToken);

            // Update properties
            existingInstructor.ApplicationUser.FirstName = instructor.ApplicationUser.FirstName;
            existingInstructor.ApplicationUser.LastName = instructor.ApplicationUser.LastName;
            existingInstructor.ApplicationUser.Email = instructor.ApplicationUser.Email;
            existingInstructor.Expertise = instructor.Expertise;
            existingInstructor.Biography = instructor.Biography;
            existingInstructor.ApplicationUser.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<Instructor>().UpdateAsync(existingInstructor, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return existingInstructor;
        }

        public async Task DeleteInstructorAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var instructor = await GetInstructorByIdAsync(id, cancellationToken);

            await _unitOfWork.Repository<Instructor>().RemoveAsync(instructor, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

    }
