﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceFarmacia.Models.Response
{
    public class Respuesta<T>
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }

        public Respuesta()
        {
            this.Exito = 0;
        }

    }
}
