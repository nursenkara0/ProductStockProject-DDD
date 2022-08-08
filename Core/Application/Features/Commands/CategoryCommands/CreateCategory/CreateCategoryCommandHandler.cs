using Application.Repositories.CategoryRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Category category = new Category
            {
                Id = id,
                Name = request.Name,
                Description = request.Description
            };

            var result = await _categoryWriteRepository.AddAsync(category);

            await _categoryWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateCategoryCommandResponse { Success = result, Message = result ? "Category is created successfully" : "Category creation is failed" };
        }
    }
}
