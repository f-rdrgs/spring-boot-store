package com.sandbox.spring_store_test.repositories.models;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

@Entity
@Table(name = "\"user\"")
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    

    @Column(name="email",unique = true)
    private String email;

    @Column(name="password")
    private String password;

    public String password(){
        return this.password;
    }

    public String email(){
        return this.email;
    }

    public Long id(){
        return this.id;
    }

    public void email(String email){
        this.email = email;
    }

    public void password(String password){
        this.password = password;
    }

    public User() {     
    }

    public User(String email) {
        this.email = email;
        this.password = "";
    }

    public User(String email, String password) {
        this.email = email;
        this.password = password;
    }
}
