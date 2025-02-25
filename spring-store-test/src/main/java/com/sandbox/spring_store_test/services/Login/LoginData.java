package com.sandbox.spring_store_test.services.Login;

public record LoginData(String email, String password) {
    public static record JWTData(String token) {
    }
}