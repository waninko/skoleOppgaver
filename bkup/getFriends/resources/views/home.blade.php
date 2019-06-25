@extends('layouts.app')

@section('title')
    Log In
@endsection

@section('content')
@if(count($errors)> 0)
<div class="row">
    <div class="col-md-6">
       <ul>
            @foreach($errors->all() as $error)
                <li>{{$error}}</li>
            @endforeach
       </ul>
    </div>
</div>
@endif
<div class="container">
<div class="row">

    <div class="col-md-4 col-md-offset-4">
    <form action="{{ route('signup') }}" method="post">
            <h3>Sign Up</h3>
            <div class="form-group  {{ $errors->has('email') ? 'has-error has-feedback' : ''}}">
                <label for="email">Your Email</label>
            <input class="form-control {{ $errors->has('email') ? 'is-invalid' : '' }}" type="text" name="email" id="email" value="{{ Request::old('email') }}">
            </div>
            <div class="form-group">
                <label for="firstname">Your First Name</label>
                <input class="form-control {{ $errors->has('firstname') ? 'is-invalid' : '' }}" type="text" name="firstname" id="firstname" value="{{ Request::old('firstname') }}">
            </div>
            <div class="form-group">
                    <label for="lastname">Your Last Name</label>
                    <input class="form-control {{ $errors->has('lastname') ? 'is-invalid' : '' }}" type="text" name="lastname" id="lastname" value="{{ Request::old('lastname') }}">
                </div>
            <div class="form-group">
                <label for="password">Your Password</label>
                <input class="form-control {{ $errors->has('password') ? 'is-invalid' : '' }}" type="password" name="password" id="password">
            </div>
            <button class="btn btn-primary" type="submit">Submit</button>
            <input type="hidden" name="_token" value="{{ Session::token() }}">
        </form>
    </div>
    <div class="col-md-6">
        <h3>Sign In</h3>
    <form action="{{ route('signin') }}" method="post">
            <div class="form-group">
                <label for="email">Your Email</label>
                <input class="form-control {{ $errors->has('email') ? 'is-invalid' : '' }}" type="text" name="email" id="email">
            </div>

            <div class="form-group">
                <label for="password">Your Password</label>
                <input class="form-control {{ $errors->has('password') ? 'is-invalid' : '' }}" type="password" name="password" id="password">
            </div>
            <button class="btn btn-primary" type="submit">Submit</button>
            <input type="hidden" name="_token" value="{{ Session::token() }}">
        </form>
    </div>
</div>
</div>
@endsection
