package com.sandbox.spring_store_test.configs;

import org.springframework.boot.context.properties.ConfigurationProperties;

@ConfigurationProperties(prefix = "login-prop")
public record LoginConfigProperties(String sha256token, String salt) {
}
