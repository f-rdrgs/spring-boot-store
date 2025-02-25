package com.sandbox.spring_store_test.services.Login;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.stream.Stream;

public class PayloadLogin {
    Map<String,String> claims;


    public PayloadLogin addClaim(String name, String value){
        claims.put(name, value);
        return this;
    }

    public PayloadLogin() {
        claims = new HashMap<String,String>();
    }

    public static PayloadLogin newPayload(){
        return new PayloadLogin();
    }
    
    @Override
    public String toString() {

        Iterator<Map.Entry<String,String>> iter = claims.entrySet().iterator();
        boolean firstIter = true;
        String printMessage = "{";
        while(iter.hasNext()){
            Map.Entry<String,String> entry = iter.next();
            String key = entry.getKey(),value = entry.getValue();
            printMessage +=String.format("%s\"%s\":\"%s\"", firstIter ? "" : ",",key,value);
            firstIter = false;
        }
        printMessage+="}";
        return printMessage;
    }
}
