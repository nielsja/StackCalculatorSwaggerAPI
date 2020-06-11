using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StackCalculatorWebAPI.Controllers
{
    [ApiController]
    public class StackController : ControllerBase
    {
        static Stack<decimal> stack = new Stack<decimal>();

        [HttpGet]
        [Route("api/Test")]
        public string Test()
        {
            return "Success";
        }

        [HttpPost]
        [Route("api/Push")]
        public IActionResult Push([FromBody]decimal number)
        {
            if (stack.Count < 10)
            {
                stack.Push(number);
                return Ok();
            }
            else
            {
                string errorMessage = "Error: Stack is full; could not Push " + number + " on to stack.";
                return new BadRequestObjectResult(errorMessage);
            }
        }

        [HttpPost]
        [Route("api/PushQuery")]
        public IActionResult PushQuery(decimal number)
        {
            if (stack.Count < 10)
            {
                stack.Push(number);
                return Ok();
            }
            else
            {
                string errorMessage = "Error: Stack is full; could not Push " + number + " on to stack.";
                return new BadRequestObjectResult(errorMessage);
            }
        }

        [HttpDelete]
        [Route("api/Pop")]
        public IActionResult Pop()
        {
            if (stack.Count == 0)
            {
                string errorMessage = "Error: Stack is empty; could not Pop.";
                return new BadRequestObjectResult(errorMessage);
            }
            else
            {
                string popped = stack.Pop().ToString();
                return new OkObjectResult(popped);
            }
        }

        [HttpGet]
        [Route("api/Print")]
        public IActionResult Print()
        {
            if (stack.Count == 0)
            {
                string errorMessage = "Error: Stack is empty; nothing to Print.";
                return new BadRequestObjectResult(errorMessage);
            }
            else
            {
                string printed = stack.Peek().ToString();
                return new OkObjectResult(printed);
            }
        }

        [HttpGet]
        [Route("api/Add")]
        public IActionResult Add()
        {
            if (stack.Count < 2)
            {
                string errorMessage = "Error: Stack only has " + stack.Count + " items. Could not execute.";
                return new BadRequestObjectResult(errorMessage);
            }
            else
            {
                var pop1 = stack.Pop();
                var pop2 = stack.Pop();
                var result = pop2 + pop1;
                stack.Push(result);
                return Ok();
            }
        }

        [HttpGet]
        [Route("api/Subtract")]
        public IActionResult Subtract()
        {
            if (stack.Count < 2)
            {
                string errorMessage = "Error: Stack only has " + stack.Count + " items. Could not execute.";
                return new BadRequestObjectResult(errorMessage);
            }
            else
            {
                var pop1 = stack.Pop();
                var pop2 = stack.Pop();
                var result = pop2 - pop1;
                stack.Push(result);
                return Ok();
            }
        }

        [HttpGet]
        [Route("api/Multiply")]
        public IActionResult Multiply()
        {
            if (stack.Count < 2)
            {
                string errorMessage = "Error: Stack only has " + stack.Count + " items. Could not execute.";
                return new BadRequestObjectResult(errorMessage);
            }
            else
            {
                var pop1 = stack.Pop();
                var pop2 = stack.Pop();
                var result = pop2 * pop1;
                stack.Push(result);
                return Ok();
            }
        }

        [HttpGet]
        [Route("api/Divide")]
        public IActionResult Divide()
        {
            if (stack.Count < 2)
            {
                string errorMessage = "Error: Stack only has " + stack.Count + " items. Could not execute.";
                return new BadRequestObjectResult(errorMessage);
            }
            else
            {
                var pop1 = stack.Pop();
                var pop2 = stack.Pop();
                var result = pop2 / pop1;
                stack.Push(result);
                return Ok();
            }
        }
    }
}