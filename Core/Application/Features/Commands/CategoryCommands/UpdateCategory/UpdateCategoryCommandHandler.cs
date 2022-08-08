using Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {

            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = "Category is not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            category.Name = request.Name ?? category.Name;
            category.Description = request.Description ?? category.Description;

            _categoryWriteRepository.Update(category);

            await _categoryWriteRepository.SaveAsync();

            return new UpdateCategoryCommandResponse
            {
                Success = true,
                Message = "Category is updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateCategoryCommandRequest request)
        {
            if (request.Name == null &&
                request.Description == null &&
                request.Slug == null)
            {
                return true;
            }

            return false;
        }
    }
}
