package com.sandbox.spring_store_test.services.Login;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.auth0.jwt.JWT;
import com.auth0.jwt.JWTVerifier;
import com.auth0.jwt.algorithms.Algorithm;
import com.auth0.jwt.exceptions.JWTVerificationException;
import com.auth0.jwt.interfaces.DecodedJWT;
import com.sandbox.spring_store_test.configs.LoginConfigProperties;
import com.sandbox.spring_store_test.repositories.models.User;
import com.sandbox.spring_store_test.services.UserService;
import com.sandbox.spring_store_test.services.Utils;
import com.sandbox.spring_store_test.services.Login.LoginData.JWTData;

import jakarta.validation.Valid;





@RestController
@RequestMapping("/auth")
public class LoginController {


    @Autowired
    private final LoginConfigProperties loginConf;

    @Autowired
    private final UserService userService;


    @PostMapping("/jwt-check")
    public ResponseEntity<LoginData.JWTData> CheckJwt(@RequestBody LoginData.JWTData data){
     try{
        
        DecodedJWT decodedJWT;
        System.out.println(data.token());
        Algorithm algo = Algorithm.HMAC256(loginConf.sha256token());
        JWTVerifier verifier = JWT.require(algo).withIssuer("myApp").build();

        decodedJWT = verifier.verify(data.token());
        
        return new ResponseEntity<LoginData.JWTData>(data,HttpStatus.OK);
    }
        catch (JWTVerificationException e){
            System.out.printf("Error while verifying JWT: %s",e);
            return new ResponseEntity<LoginData.JWTData>(data,HttpStatus.BAD_REQUEST);
        }
    }

    @PostMapping("/register")
    public ResponseEntity<LoginData.JWTData> Register(@Valid @RequestBody LoginData data) {
        
        JWTData response = userService.createUser(new User(data.email(),data.password()));
        return new ResponseEntity<LoginData.JWTData>(response,(!response.token().equals("") ? HttpStatus.OK : HttpStatus.BAD_REQUEST));
    }
    
    @DeleteMapping("/delete/{email}")
    public boolean deleteUser(@PathVariable("email") String email){
        return userService.deleteUser(new User(email));
    }
    @GetMapping("/jwt-get")
    public ResponseEntity<LoginData.JWTData> GetJwt(){
        System.out.println(new PayloadLogin()
        .addClaim("test", "oh")
        .addClaim("ah", "haha").toString());
        return new ResponseEntity<LoginData.JWTData>(userService.IssueJWT(""),HttpStatus.OK); 
    }

    @PostMapping("/login")
    public ResponseEntity<LoginData.JWTData> login(@RequestBody LoginData data) {
        User user = new User(data.email(),data.password());
        System.out.println(user.password());
        boolean passwordValid = userService.verifyPassword(user);
    
        if(!passwordValid){
            System.out.println("Password invalid");
            return new ResponseEntity<LoginData.JWTData>(new LoginData.JWTData(""),HttpStatus.BAD_REQUEST);
        }

        LoginData.JWTData JWT = userService.emitLoginJWT(userService.findUserFromMailOrID(user));
        return new ResponseEntity<LoginData.JWTData>(JWT, JWT.token().isEmpty() ? HttpStatus.BAD_REQUEST : HttpStatus.OK);    
    }
    

    public LoginController(LoginConfigProperties logConf, UserService userService) {
        this.loginConf = logConf;
        this.userService = userService;
    }
}
