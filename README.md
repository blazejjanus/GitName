# GitName

Simple app for generating conventional commits and branch names.

Usage:
  - -b - generate branch name
  - -c - generate commit name

## Branch names

Currently app allows to generate branch names in such format:

type/task/description

Where type is one of predefined types, task is task number in format used by JIRA (SPACE-NUMBER).

## Commits
Supported commits features:
- predefined types
- area
- changes list
- referred tasks
- breaking changes
