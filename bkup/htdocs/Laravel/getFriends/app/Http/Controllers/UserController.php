<?php

namespace App\Http\Controllers;

use App\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class UserController extends Controller
{
    public function __construct(){
        $this->middleware('guest')->except('getDashboard');
    }
    public function getDashboard()
    {
        return view('dashboard');
    }

    public function postSignUp(Request $request)  //request får info fra "name" input felt bl.a
    {
        $this->validate($request, [  //sett opp "regler" for validering av input
            'email' => 'required|email|unique:users',
            'first_name' => 'required|max:50',
            'last_name' => 'required|max:50',
            'password' => 'required|min:3'
        ]);

        $email = $request['email'];
        $first_name = $request['first_name'];
        $last_name = $request['last_name'];
        $password = bcrypt($request['password']);

        $user = new User();
        $user->email = $email;
        $user->first_name = $first_name;
        $user->last_name = $last_name;
        $user->password = $password;

        $user->save();

        Auth::login($user);

        return redirect()->route('dashboard');
    }

    public function postSignIn(Request $request)
    {
        $this->validate($request, [  //sett opp "regler" for validering av input
            'email' => 'required',
            'password' => 'required'
        ]);
       if (Auth::attempt(['email' => $request['email'], 'password' => $request['password']])){
           return redirect()->route('dashboard');
       }
       return redirect()->back();
    }
}
