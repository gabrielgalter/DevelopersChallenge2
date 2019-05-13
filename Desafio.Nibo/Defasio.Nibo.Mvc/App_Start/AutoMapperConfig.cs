using AutoMapper;
using Defasio.Nibo.Application.UseCases.ImportOfx;
using Defasio.Nibo.Mvc.Models;
using Desafio.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Defasio.Nibo.Mvc.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(map =>
            {                
                map.CreateMap<TransacaoModel, Transacao>().ForMember(destino => destino.IdArquivo, opt => opt.MapFrom(fonteEntrada => fonteEntrada.IdArquivo))
                                                          .ForMember(destino => destino.Tipo, opt => opt.MapFrom(fonteEntrada => fonteEntrada.Tipo))                                                            
                                                          .ForMember(destino => destino.Data, opt => opt.MapFrom(fonteEntrada => ConvertToDateTime(fonteEntrada.Data)))
                                                          .ForMember(destino => destino.Valor, opt => opt.MapFrom(fonteEntrada => decimal.Parse(fonteEntrada.Valor, CultureInfo.InvariantCulture)))
                                                          .ForMember(destino => destino.Nome, opt => opt.MapFrom(fonteEntrada => fonteEntrada.Nome))
                                                          ;
            });
        }

        private static DateTime ConvertToDateTime(string dateString)
        {
            return DateTime.ParseExact(dateString.Replace("[-03:EST]", ""), "yyyyMMddHHmmss", new CultureInfo("pt-BR"));
        }
    }
}