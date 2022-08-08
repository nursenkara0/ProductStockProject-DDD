using Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.Id);

            if (category is null)
            {
                return new DeleteCategoryCommandResponse
                {
                    Message = "Category is null.",
                    Success = false
                };
            }

            _categoryWriteRepository.Remove(category);

            var result = await _categoryWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteCategoryCommandResponse
            {
                Message = result == true ? "Category is deleted" : "Category is not deleted",
                Success = result
            };

        }
    }
}
