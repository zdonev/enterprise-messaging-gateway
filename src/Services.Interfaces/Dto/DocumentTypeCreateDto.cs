﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Services.Interfaces.Dto
{
    public class DocumentTypeCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DocType { get; set; } 
        public string Channel { get; set; }

        public virtual ICollection<DocumentTypeResolverCreateDto> ResolverList { get; set; }
    }
}
