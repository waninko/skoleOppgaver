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

Route::group(['middleware' => ['web']], function() {
    Route::get('/', function() {
        return view('home');
    });
});


// Route::get('/login', function () {
//     return view('pages.login');
// });
// Route::get('/register', function () {
//     return view('pages.register');
// });
// Route::get('/main', function () {
//     return view('pages.main');
// });
// Route::get('/profile{id}', function ($id) {
//     return view('pages.profile{id}');
// });
// Auth::routes();

Route::get('/home', 'HomeController@index')
        ->name('home');

Route::post('/signup','UserController@postSignUp')
        ->name('signup');

Route::post('/signin','UserController@postSignIn')
        ->name('signin');


Route::get('/dashboard', 'UserController@getDashboard')
    ->name('dashboard')
    ->middleware('auth');

