@extends('layouts.layout')

@section('title', 'Listings')


@section('content')

<div class="row">
    <div class="col-12">
            <h1>Dashboard</h1>
    </div>
</div>

<div class="row">
    <div class="col-12">
            <form action="users" method="POST" class="pb-5 pt-5">
                    <div class="form-group">
                        <label for="name">Name</label>
                        <input class="form-control" type="text" name="name" value="{{old('name')}}"> {{ $errors->first('name') }}

                        <label for="email">E-Mail</label>
                        <input class="form-control" type="text" name="email"  value="{{old('email')}}"> {{ $errors->first('email') }}

                        <label for="password">Password</label>
                        <input class="form-control" type="text" name="password"> {{ $errors->first('password') }}

                    </div>
                    <div class="form-group">
                        <label for="status">Status</label>
                        <select name="status" id="status" class="form-control">
                            <option value="" disabled>Select User Status</option>
                            <option value="1">Active</option>
                            <option value="0">Inactive</option>
                        </select>
                    </div>

                    <button type="submit" class="btn btn-warning">Add User</button>

                    @csrf
                </form>
    </div>
</div>
 <hr>
{{-- <form action="posts" method="POST" class="pb-5 pt-5">
    <div class="input-group">
        <label for="title">Title</label>
        <input type="text" name="title">

        <label for="body">Text</label>
        <input type="text" name="body">
    </div>
    <button type="submit">New Post</button>

    @csrf
</form> --}}

<div class="row">
    <div class="col-12">
            <ul>
             @foreach($users as $user)
                <li>{{ $user->name}}  </li>
             @endforeach
            </ul>
    </div>
</div>


@endsection
