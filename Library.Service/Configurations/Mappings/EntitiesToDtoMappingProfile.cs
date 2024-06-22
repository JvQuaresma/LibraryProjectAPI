using AutoMapper;
using Library.Domain.DTOs;
using Library.Domain.DTOs.Book;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Configurations.Mappings {
    public class EntitiesToDtoMappingProfile : Profile {

        public EntitiesToDtoMappingProfile() {

            CreateMap(typeof(GenericResponse<>), typeof(GenericResponse<>));
            CreateMap<Book, BookResponseDto>().ReverseMap();

        }
    }
}
