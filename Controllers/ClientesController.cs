using Clientes.Api.Entidades;
using Clientes.Api.Repositorios;
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

        lista = await _repositorio.ObtenerTodosAsync();

        return Ok(lista);
    }

    [HttpPost]
    public async Task<IActionResult> AgregarAsync([FromBody]Cliente cliente){
        int id;

        id = await _repositorio.AgregarAsync(cliente);

        return Ok(id);
    }
}