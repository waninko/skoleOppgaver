<?php

namespace App\Http\Controllers;

use App\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class UserController extends Controller
{

    public function __construct()
    {
        $this->middleware('auth', ['except' => ['home']]);
    }
    public function getDashboard(){
        return view('dashboard');
    }

    public function postSignUp(Request $request)
    {
        $this->validate($request, [  //regler for felt
            'email'=> 'required|email|unique:users',
            'firstname' => 'required|max:50',
            'lastname' => 'required|max:50',
            'password' => 'required|min:4'
        ]);

        $email = $request['email'];
        $firstname = $request['firstname'];
        $lastname = $request['lastname'];
        $password = bcrypt($request['password']);

        $user = new User();
        $user->email = $email;
        $user->firstname = $firstname;
        $user->lastname = $lastname;
        $user->password = $password;

        $user->save();

        Auth::login($user); //logger automatisk inn nylaget bruker

        return redirect()->route('dashboard');
    }

    public function postSignIn(Request $request)
    {
        $this->validate($request, [  //regler for felt
            'email'=> 'required',
            'password' => 'required'
        ]);

      if (Auth::attempt(['email' => $request['email'],
                         'password' => $request['password']
                        ])){
          return redirect()->route('dashboard');
      }
      return redirect()->back();

    }

}
