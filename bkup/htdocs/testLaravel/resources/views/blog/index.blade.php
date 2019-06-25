@extends('layouts.master')

@section('content')
    <div class="row">
        <div class="col-md-12">
            <p class="quote"> The Beautiful Laravel </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h1 class="post-title">Learning Laravel</h1>
            <p>This blog post will get you right on track with Laravel!</p>
            <p><a href="{{route('blog.post',['id' => 1])}}">Read More...</a></p>
        </div>
    </div>
    <hr>
    <div class="row">
        <div class="col-md-12">
        <h1 class="post-title">The Next steps</h1>
        <p>Understanding the Basics is great, 
        but you need to be able to make the next steps.</p>
        <p><a href="{{route('blog.post', ['id' => 2])}}">Read More...</a></p>
        </div>
    </div>
    <hr>
    <div class="row">
        <div class="col-md-12">
            <h1 class="post-title">Laravel 5.3</h1>
            <p>Though announced as a "minor release", Laravel 5.3 
            ships with some very interesting additions and features.</p>
            <p><a href="{{route('blog.post', ['id' => 3])}}">Read More...</a></p>
        </div>
    </div>
@endsection 





<!-- Gammelt testContent
    <div class="row">
    <div class="col-md-12">
    <h1>Control Structures </h1>
    @if(true)
        <p>This Only Displays If True</p>
        @else
        <p> This Only Displays If False</p>
    @endif
    <hr>
    @for($i = 0; $i < 5; $i++)
        <p>{{ $i +1 }}.iteration </p>
    @endfor
    <hr>
    <h2>XSS test</h2>
    {{"<script>alert('Hello!')</script>"}}
    {!!"<script>alert('Hello!')</script>"!!}
    </div>
</div> -->

