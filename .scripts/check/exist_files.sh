#!/bin/bash

json_data="$1"
script_comment="$2"


if [ -z "$json_data" ]; then
  echo "::Error::No JSON data provided.\n"
  echo "Usage: $0 '<JSON String>' [result_file]"
  exit 1
fi

total_count=0
missing_count=0
output=""

# Get Json Data
while read -r pair; do
  total_count=$((total_count + 1))
  key=$(echo "$pair" | jq -r '.key')
  value=$(echo "$pair" | jq -r '.value')
  if [ -f "$value" ] || [ -d "$value" ]; then
    output+="\n● $key\n  - Value : [ $value ]\n  - Exist"
  else
    missing_count=$((missing_count + 1))
    output+="\n● $key\n  - Value : [ $value ]\n  - Not Exist"
  fi
done <<< $(echo $json_data | jq -c '.[]')

if [ "$missing_count" -eq 0 ]; then
  summary="::Notice::[ $script_comment ] - Check Files All OK.. ($total_count/$total_count)"
else
  summary="::Warning::[ $script_comment ] - Check Files Not Exist File Count $missing_count.. ($((total_count - missing_count))/$total_count)"
fi

result="$summary$output"
echo -e "$result"