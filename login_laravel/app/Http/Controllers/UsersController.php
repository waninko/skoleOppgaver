<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\User;

class UsersController extends Controller
{
    public function list(){
        $users = User::all();


         return view('pages.dashboard', [
             'users' => $users,
         ]);
        }

        public function store()
         {
             $data = request()->validate([
                 'name' => 'required|min:3',
                 'email' => ' required|email',
                 'password' => 'required|min:3',
                 'status' => 'required'

             ]);

             $user = new User();
             $user->name = request('name');
             $user->email = request('email');
             $user->password = request('password');
             $user->status = request('status');
             $user->save();

             return back();
         }
}
