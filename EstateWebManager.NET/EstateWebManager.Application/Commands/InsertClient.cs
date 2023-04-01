﻿using EstateWebManager.Domain.Models.AppointmentClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class InsertClient : IRequest<Client>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
