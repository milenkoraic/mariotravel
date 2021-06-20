#!/usr/bin/env bash

# Shell script called by postgres container initdb to run scripts in specified order 
# when the container is started. When adding a database which needs to be created/seeded,
# the following structure is to be followed:
# * create a new directory with the name of the database
# * in that directory put a CreateDatabase.sql script which is responsible for creating the db
# * in the directory create another directory called ChangeScripts which should contain your change scripts
# * subdirectories in ChangeScripts are also supported

# It's bad practice to name bash files with .sh extension, but postgresql initdb script looks for
# .sh files to execute so needs to be named like that in this case.

# Enable ** globbing
shopt -s globstar 

# Iterate through all databases

for d in /docker-entrypoint-initdb.d/*; do
    if [ -d "$d" ]; then
        database_name="${d##*/}"
        echo "#"
        echo "#"
        echo "# Processing database $database_name"
        echo "#"
        
        # Execute initial CreateDatabase.sql for the db
        create_db_script="${d}/CreateDatabase.sql"
        if [ ! -f "$create_db_script" ]; then
            echo "# No CreateDatabase.sql found, aborting"
            exit 1
        fi

        psql=(psql -v "ON_ERROR_STOP=1" --quiet)
        echo "# Running ${create_db_script##*/}"
        "${psql[@]}" -f "$create_db_script"

        # Execute all change scripts for the db
        psql+=( --dbname "$database_name" )    

        change_scripts_glob="${d}/ChangeScripts/**/*.sql"

        echo "# Executing scripts:"
        for f in ${change_scripts_glob}; do
            script_name=$( echo "$f" | rev | cut -d"/" -f1,2 | rev )
            echo "# $script_name"
            "${psql[@]}" -f "$f"
        done
    fi
done