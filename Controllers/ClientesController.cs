using Clientes.Api.Entidades;
using Clientes.Api.Repositorios;
using FesAragon.dotnet.Clientes.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteRepositorio _repositorio;

    public ClientesController(ClienteRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        List<Cliente> lista;
        List<ClienteDto> listaDto;

        lista = await _repositorio.ObtenerTodosAsync();
        listaDto = lista.Select(x => new ClienteDto{
            Id = x.Id,
            Apellidos = x.Apellidos,
            Correo = x.Correo,
            Guid = Guid.Parse(x.Guid),
            Nombre = x.Nombre,
            Telefono = x.Telefono,
            Direccion = new DireccionDto{
                Alcaldia = x.Direccion.Alcaldia,
                CalleYNumero = x.Direccion.CalleYNumero,
                CodigoPostal = x.Direccion.CodigoPostal,
                Colonia = x.Direccion.Colonia,
                CoordenadasGps = x.Direccion.CoordenadasGps,
                Estado = x.Direccion.Estado,
                Referencia = x.Direccion.Referencia
            }
        }).ToList();

        return Ok(listaDto);
    }

    [HttpPost]
    public async Task<IActionResult> AgregarAsync([FromBody] ClienteDtoIn clienteDto)
    {
        int id;
        Cliente cliente;

        cliente = new Cliente
        {
            Apellidos = clienteDto.Apellidos,
            Correo = clienteDto.Correo,
            Nombre = clienteDto.Nombre,
            Guid = clienteDto.Guid.ToString(),
            Telefono = clienteDto.Telefono,
            Direccion = new Direccion
            {
                Alcaldia = clienteDto.Direccion.Alcaldia,
                CalleYNumero = clienteDto.Direccion.CalleYNumero,
                CodigoPostal = clienteDto.Direccion.CodigoPostal,
                Colonia = clienteDto.Direccion.Colonia,
                CoordenadasGps = clienteDto.Direccion.CoordenadasGps,
                Estado = clienteDto.Direccion.Estado,
                Referencia = clienteDto.Direccion.Referencia
            }
        };
        id = await _repositorio.AgregarAsync(cliente);

        return Ok(id);
    }
}