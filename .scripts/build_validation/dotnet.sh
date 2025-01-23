#!/bin/bash

project_file_path=$1
build_configuration=$2
result_file="$3"

if [ -z "$project_file_path" ] || [ -z "$build_configuration" ]; then
    echo "::Error::No arguments."
    echo "Usage: $0 <Project File Path> <Build Configuration> <Result File>"
    exit 1
fi

is_error=0
output="Building project: $project_file_path with configuration: $build_configuration os:Linux\n"

# Execute dotnet build and capture output
build_output=$(dotnet build "$project_file_path" -c "$build_configuration" 2>&1)
build_exit_code=$?

if [ $build_exit_code -ne 0 ]; then
    output+="Build failed.\n"
    output+="Error Output:\n"
    while IFS= read -r line; do
        output+="  > $line\n"
    done <<< "$build_output"

    summary="::Error::Build failed."
    is_error=1
else
    summary="::Notice::Build Test Completed Successfully."
    while IFS= read -r line; do
        output+="  > $line\n"
    done <<< "$build_output"
fi

result="$output$summary"

if [ -n "$result_file" ]; then
    # Ensure result file directory exists
    result_dir=$(dirname "$result_file")
    if [ ! -d "$result_dir" ]; then
        mkdir -p "$result_dir"
    fi
    touch $result_file
    echo -e "$result" > "$result_file"
else
    echo -e "$result"
fi

if [ $is_error -ne 0 ]; then
    exit 1
fi
