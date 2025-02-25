package com.sandbox.spring_store_test.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.sandbox.spring_store_test.repositories.models.User;

@Repository
public interface UserRepository extends JpaRepository<User,Long> {
    User findByEmailLike(String Email);

    User findByEmailLikeOrId(String Email, Long id);
}
