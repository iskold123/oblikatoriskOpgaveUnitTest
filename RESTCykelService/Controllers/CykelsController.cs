﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using oblikatoriskOpgave;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTCykelService.Controllers
{
    [Route("api/Cykels")]
    //[EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class CykelsController : ControllerBase
    {

        //Håbede jeg kunne undgå at oprette en liste her i controlleren og hente den direkte fra min cykel klasse.
        public static List<Cykel> _data = new List<Cykel>
        {
            new Cykel(3,"Blue",85,16),
            new Cykel(4,"Red",145,3),
            new Cykel(5,"Black",100,32),
            new Cykel(6,"Yellow",130,20)
        };

        // GET: api/<CykelsController>
        [HttpGet]
        //[EnableCors("AllowSpecificOrigin")]
        public IEnumerable<Cykel> Get()
        {
            return _data;
        }

        // GET api/<CykelsController>/5
        [HttpGet]
        [Route("{id}")]
        public Cykel Get(int id)
        {
            return _data.Find(i => i.Id == id);
        }

        // POST api/<CykelsController>
        [HttpPost]
        public void Post([FromBody] Cykel value)
        {
            int id = _data.Max(c => c.Id);
            value.Id = id + 1;
        }

        // PUT api/<CykelsController>/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] Cykel value)
        {
            Cykel cykel = Get(id);
            if (cykel != value)
            {
                cykel.Id = value.Id;
                cykel.Color = value.Color;
                cykel.Gear = value.Gear;
                cykel.Price = value.Price;
            }
        }

        // DELETE api/<CykelsController>/5
        [HttpDelete()]
        [Route("{id}")]
        public void Delete(int id)
        {
            Cykel cykel = Get(id);
            if (cykel != null)
            {
                _data.Remove(cykel);
            }
        }
    }
}
