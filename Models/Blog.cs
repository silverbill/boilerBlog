using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


public interface IBlogRepo {
    void add(Post p); // CREATE
    IEnumerable<Post> getAll(); // READ
    Post get(int PostId); // READ  get 1
    Post update(int PostId, Post p); // UPDATE
    void delete(int PostId); // DELETE
    //Dictionary<string, int> getBy();
    IEnumerable<Post> getTen();
}
public class Blog : IBlogRepo {
    //public IEnumerable<Post> posts = new List<Post>();
    string title;
    int BlogId;

    private List<Post> posts = new List<Post>();
    public Blog(){
        posts.Add(new Post { PostId = 1, title = "P1", content = "xxx" });
        posts.Add(new Post { PostId = 2, title = "P2" });
        posts.Add(new Post { PostId = 3, title = "P3" });
        posts.Add(new Post { PostId = 4, title = "P4" });
        posts.Add(new Post { PostId = 5, title = "P5" });
        posts.Add(new Post { PostId = 6, title = "P6" });
        posts.Add(new Post { PostId = 7, title = "P7" });
        posts.Add(new Post { PostId = 8, title = "P8" });
        posts.Add(new Post { PostId = 9, title = "P9" });
        posts.Add(new Post { PostId = 10, title = "P10", content = "supercalifragalistic" });
    }

    public void add(Post p){
        posts.Add(p);
    }
    public IEnumerable<Post> getTen(){
        int numberOfrecords=10;
        return posts.OrderByDescending(x => x.createdAt).Take(numberOfrecords);
        
    }
    public IEnumerable<Post> getAll(){
        return posts;
    }
    public Post get(int PostId){
        return posts.First(p => p.PostId == PostId);
    }
    public Post update(int PostId, Post p){
        Post toUpdate = posts.First(x => x.PostId == PostId);
        if(toUpdate != null){
            posts.Remove(toUpdate);
            posts.Add(p);
            return p;
        }
        return null;
    }
    public void delete(int PostId){
        Post p = posts.First(x => x.PostId == PostId);
        if(p != null){
            posts.Remove(p);
        }
    }
    
}