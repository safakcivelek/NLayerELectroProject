using System;
using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Core.Utilities.Results.Abstract;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Core.Utilities.Results.Concert;
using NLayer.Service.Utilities;

namespace NLayer.Service.Services
{
    public class CommentManager : ManagerBase, ICommentService
    {
        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<CommentDto>> GetAsync(int commentId)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId);
            if (comment != null)
            {
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
                {
                    Comment = comment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null
            });
        }
        public async Task<IDataResult<CommentUpdateDto>> GetCommentUpdateDtoAsync(int commentId)
        {
            var result = await UnitOfWork.Comments.AnyAsync(c => c.Id == commentId);
            if (result)
            {
                var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId);
                var commentUpdateDto = Mapper.Map<CommentUpdateDto>(comment);
                return new DataResult<CommentUpdateDto>(ResultStatus.Success, commentUpdateDto);
            }
            else
            {
                return new DataResult<CommentUpdateDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), null);
            }
        }
        public async Task<IDataResult<CommentListDto>> GetAllAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(null, c => c.Product);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }
        public async Task<IDataResult<CommentListDto>> GetAllByDeletedAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => c.IsDeleted, c => c.Product);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null
            });
        }
        public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => !c.IsDeleted, c => c.Product);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }
        public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Product);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }
        public async Task<IDataResult<CommentDto>> AddAsync(CommentAddDto commentAddDto)
        {
            var product = await UnitOfWork.Products.GetAsync(p => p.Id == commentAddDto.ProductId);
            if (product == null)
            {
                return new DataResult<CommentDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), null);
            }
            var comment = Mapper.Map<Comment>(commentAddDto);
            var addedComment = await UnitOfWork.Comments.AddAsync(comment);
            product.CommentCount += 1;
            await UnitOfWork.Products.UpdateAsync(product);
            await UnitOfWork.CommitAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.Add(commentAddDto.CreatedByName), new CommentDto
            {
                Comment = addedComment,
            });
        }
        public async Task<IDataResult<CommentDto>> UpdateAsync(CommentUpdateDto commentUpdateDto, string modifiedByName)
        {
            var oldComment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentUpdateDto.Id);
            if (oldComment != null)
            {
                var comment = Mapper.Map<CommentUpdateDto, Comment>(commentUpdateDto, oldComment);
                comment.ModifiedByName = modifiedByName;
                var updatedComment = await UnitOfWork.Comments.UpdateAsync(comment);
                updatedComment.Product = await UnitOfWork.Products.GetAsync(p => p.Id == updatedComment.ProductId);
                await UnitOfWork.CommitAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.Update(comment.CreatedByName), new CommentDto
                {
                    Comment = updatedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<CommentDto>> DeleteAsync(int commentId, string modifiedByName)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId, c => c.Product);
            if (comment != null)
            {
                var product = comment.Product;
                comment.IsDeleted = true;
                comment.IsActive = false;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var deletedComment = await UnitOfWork.Comments.UpdateAsync(comment);
                product.CommentCount -= 1;
                await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.CommitAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.Delete(deletedComment.CreatedByName), new CommentDto
                {
                    Comment = deletedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }
        public async Task<IResult> HardDeleteAsync(int commentId)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId, c => c.Product);
            if (comment != null)
            {
                if (comment.IsDeleted)
                {
                    await UnitOfWork.Comments.DeleteAsync(comment);
                    await UnitOfWork.CommitAsync();
                    return new Result(ResultStatus.Success, Messages.Comment.HardDelete(comment.CreatedByName));
                }
                var product = comment.Product;
                await UnitOfWork.Comments.DeleteAsync(comment);
                product.CommentCount = await UnitOfWork.Comments.CountAsync(c => c.ProductId == product.Id && !c.IsDeleted);
                await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.CommitAsync();
                return new Result(ResultStatus.Success, Messages.Comment.HardDelete(comment.CreatedByName));
            }
            return new Result(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false));
        }
        public async Task<IDataResult<CommentDto>> UndoDeleteAsync(int commentId, string modifiedByName)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId, c => c.Product);
            if (comment != null)
            {
                var product = comment.Product;
                comment.IsDeleted = false;
                comment.IsActive = true;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var deletedComment = await UnitOfWork.Comments.UpdateAsync(comment);
                product.CommentCount += 1;
                await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.CommitAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.UndoDelete(deletedComment.CreatedByName), new CommentDto
                {
                    Comment = deletedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }
        public async Task<IDataResult<int>> CountAsync()
        {
            var commentsCount = await UnitOfWork.Comments.CountAsync();
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }
        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var commentsCount = await UnitOfWork.Comments.CountAsync(c => !c.IsDeleted);
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }
        public async Task<IDataResult<CommentDto>> ApproveAsync(int commentId, string modifiedByName)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId, c => c.Product);
            if (comment != null)
            {
                if (!comment.IsActive)
                {

                    comment.IsActive = true;
                    comment.ModifiedByName = modifiedByName;
                    comment.ModifiedDate = DateTime.Now;
                }
                else
                {
                    comment.IsActive = false;
                    comment.ModifiedByName = modifiedByName;
                    comment.ModifiedDate = DateTime.Now;
                }
                var product = comment.Product;
                var updatedComment = await UnitOfWork.Comments.UpdateAsync(comment);
                product.CommentCount = await UnitOfWork.Comments.CountAsync(c => c.ProductId == product.Id && !c.IsDeleted);
                await UnitOfWork.CommitAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.Approve(commentId), new CommentDto
                {
                    Comment = updatedComment
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), null);
        }
    }
}
