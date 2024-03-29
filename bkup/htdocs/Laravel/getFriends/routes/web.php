<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/



Route::group(['middleware' => ['web']], function(){
    Route::get('/', function () {
        return view('welcome');
    });

    Route::post('/signup', [
        'uses' => "UserController@postSignUp",
        'as' => 'signup'
    ]);

    Route::post('/signin', [
        'uses' => "UserController@postSignIn",
        'as' => 'signin'
    ]);
});



Route::get('/dashboard', 'UserController@getDashboard')->name('dashboard')->middleware('auth');


Auth::routes();

Route::get('/home', 'HomeController@index')->name('home');
