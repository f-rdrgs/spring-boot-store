package com.sandbox.spring_store_test.repositories.models;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.SequenceGenerator;
import jakarta.persistence.Table;

@Entity
@Table(name = "\"users\"")
public class Users {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO, generator = "users_id_seq")
    @SequenceGenerator(name = "users_id_seq", sequenceName = "users_id_seq", allocationSize = 1)
    private int id;
    

    @Column(name="email",unique = true)
    private String email;

    @Column(name="password")
    private String password;

    @Column(name="username")
    private String username;

    public String password(){
        return this.password;
    }

    public String username(){
        return this.username;
    }

    public String email(){
        return this.email;
    }

    public int id(){
        return this.id;
    }

    public void email(String email){
        this.email = email;
    }

    public void password(String password){
        this.password = password;
    }

    public void username(String username){
        this.username = username;
    }

    public Users() {    
        this.email = "";
        this.username = "";
        this.password = ""; 
    }
    
    public Users(String email) {
        this.email = email;
        this.username = "";
        this.password = "";
    }

    public Users(String email, String password) {
        this.email = email;
        this.username = "";
        this.password = password;
    }

    public Users(String username,String email, String password) {
        this.email = email;
        this.username = username;
        this.password = password;
    }
}
