@extends('layouts.master')

@section('title')
    Welcome to getFriends!
@endsection

@section('content')
@if(count($errors) > 0) <!-- Error Log -->
<div class="row">
    <div class="col-md-4 col-md-offset-4">
        <ul>
            @foreach($errors->all() as $error)
                <li>{{ $error }} </li>
            @endforeach
        </ul>
    </div>
</div>
@endif
    <div class="row">
        <div class="col-md-6">
        <h3>Sign In</h3>
        <form action="{{ route('signin') }}"  method="post">
            <div class="form-group {{ $errors->has('email') ? 'has-error has-feedback' : ''}}">
                <label for="email"> E-Mail: </label>
            <input class="form-control {{ $errors->has('email') ? 'is-invalid' : '' }}" type="text" name="email" id="email" value="{{ Request::old('email') }}">
            </div>
            <div class="form-group">
                <label for="password">Password: </label>
                <input class="form-control {{ $errors->has('password') ? 'is-invalid' : '' }}" type="password" name="password" id="password">
            </div>
            <button type="submit" class="btn btn-warning">Sign In</button>
            <input type="hidden" name="_token" value="{{ Session::token() }}"> <!--henter denne session's token - unngå token mismatch error -->
        </form>
        </div>

        <div class="col-md-6">
                <h3>Sign Up</h3>
            <form action="{{ route('signup') }}" method="post">
                <div class="form-group {{ $errors->has('email') ? 'has-error has-feedback' : ''}}">
                    <label for="email"> E-Mail: </label>
                    <input class="form-control {{ $errors->has('email') ? 'is-invalid' : '' }}" type="text" name="email" id="email" value="{{ Request::old('email') }}">
                </div>
                <div class="form-group">
                    <label for="first_name">First Name: </label>
                    <input class="form-control {{ $errors->has('first_name') ? 'is-invalid' : '' }}" type="text" name="first_name" id="first_name" value="{{ Request::old('first_name') }}">
                </div>
                <div class="form-group">
                    <label for="last_name"> Last Name: </label>
                    <input class="form-control {{ $errors->has('last_name') ? 'is-invalid' : '' }}" type="text" name="last_name" id="last_name" value="{{ Request::old('last_name') }}">
                </div>
                <div class="form-group">
                    <label for="password">Password: </label>
                    <input class="form-control {{ $errors->has('password') ? 'is-invalid' : '' }}" type="password" name="password" id="password">
                </div>
            <button type="submit" class="btn btn-warning">Submit Registration</button>
            <input type="hidden" name="_token" value="{{ Session::token() }}"> <!--henter denne session's token -->
            </form>
        </div>
    </div>
@endsection
