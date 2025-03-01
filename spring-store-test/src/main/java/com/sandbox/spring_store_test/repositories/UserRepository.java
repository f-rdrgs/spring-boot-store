package com.sandbox.spring_store_test.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.sandbox.spring_store_test.repositories.models.Users;

@Repository
public interface UserRepository extends JpaRepository<Users,Integer> {
    Users findByEmailLike(String Email);

    Users findByEmailLikeOrId(String Email, int id);
}
