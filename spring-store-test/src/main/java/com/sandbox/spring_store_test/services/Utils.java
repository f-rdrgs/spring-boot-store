package com.sandbox.spring_store_test.services;


import com.auth0.jwt.JWT;
import com.auth0.jwt.algorithms.Algorithm;
import com.sandbox.spring_store_test.configs.LoginConfigProperties;

import at.favre.lib.crypto.bcrypt.BCrypt;


public class Utils {
    public static String CreateToken(String sha256tok,String PayloadJSON){
        try {
            
            Algorithm algo = Algorithm.HMAC256(sha256tok);
            return JWT.create()
            .withIssuer("myApp")
            .withClaim("issuedAt",java.time.Clock.systemUTC().millis())
            .withPayload(PayloadJSON)
            .sign(algo);
        } catch (Exception e) {
            System.err.printf("Error during token creation: %s\n",e.toString());
            return "";    
        }
    }

    public static String HashPassword(String pwd,LoginConfigProperties logConf){
        try {
            return BCrypt.withDefaults().hashToString(12, pwd.toCharArray());
            
        } catch (Exception e) {
            System.out.printf("Error while hashing password: %s\n",e);
            return "";
        }
    }

    public static boolean VerifyPasswords(String pwd1, String pwd_hashed, LoginConfigProperties logConf){
        try {
           return BCrypt.verifyer().verify(pwd1.toCharArray(),pwd_hashed).verified;
        } catch (Exception e) {
            System.out.printf("Error while verifying passwords: %s\n",e);
            return false;
        }
    }
}
