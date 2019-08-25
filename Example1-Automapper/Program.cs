using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Example1_Automapper
{/// <summary>
/// Simple auto mapper class without projection
/// </summary>
    class Program
    {
        /// <summary>
        /// Mapping to be done from Source to the Destination
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            AuthorModel _modelSource = new AuthorModel();
            _modelSource.AuthorId = 001;
            _modelSource.AuthorName = "Rabindranath Tagore";
            _modelSource.AuthorBook = "Gitanjali";
            //_modelSource.AuthorPhoneNumber = 0032441139;
            MapperConfiguration configuration = new MapperConfiguration(
                cfg=> { cfg.CreateMap<AuthorModel, AuthorDto>();
                });
            IMapper imapper = configuration.CreateMapper();
            var destination = imapper.Map<AuthorModel, AuthorDto>(_modelSource);

            /*for list*/
            List<AuthorModel> modelsList = new List<AuthorModel>
            {
                new AuthorModel{AuthorId=002,AuthorName="Anton Chekov",AuthorBook="Last Leaf"},
                new AuthorModel{AuthorId=003,AuthorName="Ruskin Bond",AuthorBook="Night Train At Deoli"},
                new AuthorModel{AuthorId=004,AuthorName="R K Narayan",AuthorBook="Malgudi days"},
                new AuthorModel{AuthorId=005,AuthorName="Amish Tripathi",AuthorBook="Mehula"},
            };
            var destinationList = imapper.Map<List<AuthorModel>, List<AuthorDto>>(modelsList);
        }
    }
    /// <summary>
    /// Source
    /// </summary>
    class AuthorModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorBook { get; set; }
    }
    /// <summary>
    /// Destination
    /// </summary>
    class AuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorBook { get; set; }
        public int AuthorPhoneNumber { get; set; }

    }
}
