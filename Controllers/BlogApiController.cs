using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;


//public static string ToJSON(Object o) => JsonConvert.SerializeObject(o);

[Route("/api/blog")]
public class BlogApiController : Controller {
    private IBlogRepo blog;
    public BlogApiController(IBlogRepo b){
        blog = b;
    }

    [HttpGet] 
    public IActionResult getAll(){  //checks: read all

        return Ok(blog.getAll());
    }

    [HttpGet("{PostId}")]
    public IActionResult ReadOne(int PostId){    //checks:  read one
        var post = blog.get(PostId);
        if(post == null)
            return NotFound(); //404
        
        return Ok(blog.get(PostId));
    }

   [HttpPut("{PostId}/edit")]
    public IActionResult update([FromBody]Post p, int PostId){  //update 1
        if(blog.update(PostId, p) == null){
            return NotFound();
        }
        return Ok(blog.update(PostId, p));
    }

    [HttpPost]
        public IActionResult Create([FromBody]Post p){  //add 1 checks
            blog.add(p);
            return Ok(blog.getAll());
        }

    [HttpPost("delete/{PostId}")]
    // 
    public IActionResult Delete(int PostId){
        blog.delete(PostId);
        return Ok(blog.getAll());
    }

}