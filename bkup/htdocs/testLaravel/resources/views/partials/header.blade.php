<nav class="navbar navbar-default">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">MyFirstLaravelPage</a>
    </div>
    <ul class="nav navbar-nav">
      <li class="active"><a href="#">LaravelGuide</a></li>
      <li><a href="{{route('blog.index')}}">Blog</a></li>
      <li><a href="{{route('other.about')}}">About</a></li>
    </ul>
  </div>
</nav>