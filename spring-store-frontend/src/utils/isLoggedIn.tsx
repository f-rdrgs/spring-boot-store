import Cookies from 'js-cookie'

function isLoggedIn(){
    Cookies.get('login-tok')
}

export default isLoggedIn;