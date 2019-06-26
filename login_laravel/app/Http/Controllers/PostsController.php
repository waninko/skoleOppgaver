<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Post;

class PostsController extends Controller
{
   public function list(){
   $posts = Post::all();


    return view('pages.dashboard', [
        'posts' => $posts,
    ]);
   }

   public function store()
    {
        $data = request()->validate([
            'title' => 'required|min:3',
            'body' => 'required|min:3|max:60'
        ]);

        $post = new Post();
        $post->title = request('title');
        $post->body = request('body');
        $post->save();

        return back();
    }

}
