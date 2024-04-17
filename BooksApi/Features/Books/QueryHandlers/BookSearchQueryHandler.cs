using AutoMapper;
using BooksApi.Features.Books.Dtos;
using BooksApi.Features.Books.Queries;
using BooksApi.Infrastructure.Repositories;
using MediatR;
using NinjaNye.SearchExtensions;

namespace BooksApi.Features.Books.QueryHandlers
{
    public class BookSearchQueryHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<BookSearchQuery, IEnumerable<BookDto>>
    {
        public async Task<IEnumerable<BookDto>> Handle(BookSearchQuery request, CancellationToken cancellationToken)
        {
            var excludedKeywords = new List<string>() { "the", "in", "they", "and", "of" };
            var searchTerms = request
                .SearchQuery
                .ToLower()
                .Split(
                    new char [] { ',', ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries
                )
                .Where(x => !excludedKeywords.Contains(x))
                .ToArray();

            var books = bookRepository.GetAll()
                .Search(
                    x => x.Title,
                    x => x.Genre,
                    x => x.Description,
                    x => x.Author
                ).Containing(searchTerms)
                .ToRanked()
                .OrderByDescending(x => x.Hits)
                .Where(x => x.Hits > 0)
                .Select(x => x.Item);

            return mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
