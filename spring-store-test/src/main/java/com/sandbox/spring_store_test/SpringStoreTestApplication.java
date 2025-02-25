package com.sandbox.spring_store_test;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

import com.sandbox.spring_store_test.configs.LoginConfigProperties;

@SpringBootApplication
@EnableConfigurationProperties(LoginConfigProperties.class)
@EnableJpaRepositories(basePackages = "com.sandbox.spring_store_test.repositories")
public class SpringStoreTestApplication {

	public static void main(String[] args) {
		SpringApplication.run(SpringStoreTestApplication.class, args);
	}


}
