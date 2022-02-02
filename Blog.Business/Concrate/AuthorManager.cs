using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.Domain.Concrete;
using Blog.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrate
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;
        Imapper _mapper;

        public AuthorManager(IAuthorDal authorDal, Imapper mapper)
        {
            _authorDal = authorDal;
            _mapper = mapper;
        }
        public void Add(Author entity)
        {
            entity.RegisterDate = DateTime.Now;
            _authorDal.Add(entity);
        }

        public void Delete(Author entity)
        {
            _authorDal.Delete(entity);
        }

        public Author Get(Expression<Func<Author, bool>> filter = null)
        {
            return _authorDal.Get(filter);
        }

        public List<Author> GetList(Expression<Func<Author, bool>> filter = null)
        {
            List<AuthorListDto> authorList = _mapper.Map<List<AuthorListDto>>(author);
            return _authorDal.GetList(filter);
        }

        public void Update(Author entity)
        {
            _authorDal.Update(entity);
        }
    }
}
