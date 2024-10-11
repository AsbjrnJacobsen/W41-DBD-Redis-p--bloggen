# Relations:
User - Blog (One to few)    
User - Post (One to many)   
User - Comment (One to many)            

Blog - Post (One to many)

Post - Comment (One to many)    
Comment - Comment (One to one)

# Why this design?
Our assignment is: "You should model the following entities: users, blogs, posts, comments."

With our design the structure of the system is integrated into the DB.
Which means that the data availability will be more accurate and efficient, compared to
a system that is unstructured. 

The design structure / choices we have made fit our system and not necessarily any other system. 
I.e it is customized to our systems needs. For our system, it means more efficient data handling as we expect our system
to be used according to the design choices we have made. 

The MongoDB Dev article we read, mentioned a rule. The rule is: 
"Needing to access an object on its own is a compelling reason not to embed it."
We think it is a good rule to follow which is why we have done so.
This of course means that we get a higher degree of modularity compared to a single document. 