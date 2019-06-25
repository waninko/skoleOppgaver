<?php

namespace App;


use Illuminate\Auth\Authenticatable;

use Illuminate\Database\Eloquent\Model;

use Illuminate\Auth\Passwords\CanResetPassword;

use Illuminate\Foundation\Auth\Access\Authorizable
;
use Illuminate\Contracts\Auth\Authenticatable as AuthenticatableContract;



class User extends Model implements AuthenticatableContract

{
    use Authenticatable;
}
