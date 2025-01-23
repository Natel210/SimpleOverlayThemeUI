#!/bin/bash

# Read arguments
event_name="${1}"
ref="${2:-unknown_ref}"
head_ref="${3:-unknown_head_ref}"
base_ref="${4:-unknown_base_ref}"

if [ "$#" -lt 1 ]; then
  echo "::Error::No arguments."
  echo "Usage: $0 '<Git Event Name>'"
  exit 1
fi


is_error=0
# Handle different events
case "$event_name" in
  push)
    output="\033[38;5;245m● Detail\033[0m"
    output+="\n\033[38;5;245m  - Event : Push\033[0m"
    output+="\n\033[38;5;245m  - Ref: $ref\033[0m"
    if [[ "$ref" == refs/heads/* ]]; then
      branch_name=${ref#refs/heads/}
      output+="\n\033[38;5;245m  - Branch: $branch_name\033[0m"
      summary="\033[38;5;46mPush Branch : $branch_name\033[0m\n"
    elif [[ "$ref" == refs/tags/* ]]; then
      tag_name=${ref#refs/tags/}
      output+="\n\033[38;5;245m  - Branch: $tag_name\033[0m"
      summary="\033[38;5;46mPush Tag : $tag_name\033[0m\n"
    else
      output+="\033[0m\n\033[0m  - \033[38;5;196mUnknown\033[0m"
      summary="\033[38;5;196mPush Unknown\033[0m\n"
      is_error=1
    fi
    ;;
  pull_request)
    summary="\033[0mPull Request"
    output="\033[38;5;245m● Detail\033[0m"
    output+="\033[38;5;245m\n  - Event : \033[38;5;46mPull Request\033[0m\n"
    if [[ "$head_ref" == refs/heads/* ]]; then
      output+="\033[0m\n\033[0m  - Head Ref : \033[38;5;196m$head_ref\033[0m"
      summary+="$\n  \033[38;5;196mInvalid Head Ref ($head_ref)\033[0m"
      is_error=1
    else
      output+="\033[38;5;245m\n  - Head Ref : $head_ref\033[0m"
    fi
    if [[ "$base_ref" == refs/heads/* ]]; then
      output+="\033[0m\n\033[0m  - Base Ref : \033[38;5;196m$base_ref\033[0m"
      summary+="\n  \033[38;5;196mInvalid Base Ref ($base_ref)\033[0m"
      is_error=1
    else
      output+="$\n  - Base Ref : $base_ref\033[0m"
    fi
    
    if [[ "$is_error" == "0" ]]; then
      head_branch_name=${head_ref#refs/heads/}
      base_branch_name=${base_ref#refs/heads/}
      output+="\033[38;5;245m\n  - Head Branch : $head_branch_name\033[0m"
      output+="\033[38;5;245m\n  - Base Branch : $base_branch_name\033[0m"
      output+="\033[38;5;245m\n  $head_branch_name -> $base_branch_name\033[0m"
      summary="${summary} : \033[38;5;46m$head_branch_name -> $base_branch_name\033[0m"
    else
      summary="${summary}\033[0m"
    fi
    summary+="\n"
    ;;
  *)
    output="Event : $event_name\n"
    output+="Unknown Event Type"
    summary="::Error::Unknown Event Type ($base_ref)"
    is_error=1
    ;;
esac


result="$summary$output"
echo "$result"

if [ $is_error != 0 ]; then
  exit 1
fi