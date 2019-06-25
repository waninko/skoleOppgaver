<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\User;

class DashboardController extends Controller
{
    public function __construct()
    {
        $this->middleware('auth');
    }

    public function getDashboard()
    {
        $user_id = auth()->user()->id;
        $user = User::find($user_id);
        return view('dashboard');
    }
}
