---
presentation:
  enableSpeakerNotes: true
  theme: beige.css
  transition: none
  transitionSpeed: fast
---

<!-- slide -->

# Writing Test plans

Documenting test cases and your reasoning

<!-- slide -->

Test plans document

- what we will test in functional terms, and
- why we have chosen to test that

Test cases are implemented in code

Test plans and test cases are linked by tooling

This way, we avoid redundancy

<!-- slide -->

Principles

- Combinatorial testing
  - Mathematical approach, *pairwise* or *all ways*
  - Using business knowledge to break down

<!-- slide -->

## What can possibly affect the outcome of tests

Input parameters

- `User ID`
  An integer (4294967296 possible values)
- `Include invoices`
  A Boolean (2 possible values)
