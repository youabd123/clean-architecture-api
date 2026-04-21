using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CleanArchitectureApi.Domain.Entities;

namespace CleanArchitectureApi.Application.Features.Products
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;
    
       
    }
