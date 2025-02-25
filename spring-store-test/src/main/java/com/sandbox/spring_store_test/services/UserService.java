package com.sandbox.spring_store_test.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.sandbox.spring_store_test.configs.LoginConfigProperties;
import com.sandbox.spring_store_test.repositories.UserRepository;
import com.sandbox.spring_store_test.repositories.models.User;
import com.sandbox.spring_store_test.services.Login.LoginData;
import com.sandbox.spring_store_test.services.Login.PayloadLogin;
import com.sandbox.spring_store_test.services.Login.LoginData.JWTData;

import ch.qos.logback.classic.pattern.Util;

@Service
public class UserService {
    @Autowired
    private UserRepository userRepository;

    @Autowired
    private LoginConfigProperties loginConf;

    public JWTData createUser(User user){
        try {
            user.password(Utils.HashPassword(user.password(), loginConf).toString());
            System.out.println(user.password());
            userRepository.save(user);  
            return IssueJWT(PayloadLogin.newPayload().addClaim("id", user.id().toString()).toString());
        } catch (Exception e) {
            System.out.println("Error while creating user: "+e);
            return new JWTData("");
        }
    }
    public JWTData emitLoginJWT(User user){
        return this.IssueJWT(PayloadLogin.newPayload().addClaim("id", user.id().toString()).toString());
    }
    public boolean deleteUser(User user){
        try{
            userRepository.delete(user);
            return true;
        }catch (Exception e){
            System.out.println("Error while deleting user: "+e);
            return false;
        }
    }

    public User findUserFromMailOrID(User user){
        try {
            return userRepository.findByEmailLikeOrId(user.email(),user.id());
        } catch (Exception e) {
            System.out.printf("An error occured when trying to find user by email %s or id %ld: %s",user.email(),user.id(),e);
            return new User();
        }
    }

    public String findEmail(User user){
        try {
            User query_res = findUserFromMailOrID(user);
            return query_res == null ? "" : query_res.email();
        } catch (Exception e) {
            System.out.printf("Error, no email found for %s: %s\n",user.email(),e);
            return "";
        }
    }

    public String findPassword(User user){
        try {
            User query_res = findUserFromMailOrID(user);
            return query_res == null ? "" : query_res.password();
        } catch (Exception e) {
            System.out.printf("Error, no password found for %s: %s\n",user.email(),e);
            return "";
        }
    }

    public boolean verifyPassword(User user){
        try {
            User query_res = this.findUserFromMailOrID(user);

            String pwd = query_res == null ? "" : query_res.password();

            if(pwd.isEmpty()){
                System.out.printf("No password was found for given user %s\n",user.email());
                return false;
            }

            if(user.password().isBlank()){
                System.out.printf("No password was given by user %s\n",user.email());
                return false;
            }
            
            return Utils.VerifyPasswords(user.password(), pwd, loginConf);


        } catch (Exception e) {
            System.out.printf("An error has occured while verifying passwords: %s",e);
            return false;
        }
    }

    public JWTData IssueJWT(String JSONPayload){
        return new LoginData.JWTData(Utils.CreateToken(loginConf.sha256token(),JSONPayload.isBlank() ? "{}" : JSONPayload));
    }
}