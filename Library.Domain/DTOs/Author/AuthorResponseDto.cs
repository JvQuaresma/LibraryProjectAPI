﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Domain.DTOs.Author {
    public class AuthorResponseDto {

        public string? Name { get; set; }
        public List<Library.Domain.Models.Book>? Books { get; set; }

    }
}
