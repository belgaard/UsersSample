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

## A Test plan documents

- *what* we will test, and
- *why* we will test that <!-- .element: class="fragment" data-fragment-index="1" -->
- in functional terms <!-- .element: class="fragment" data-fragment-index="2" -->

<!-- slide -->

## Test plan test cases

- Test cases are implemented in code

- Test plans and test cases are linked by tooling <!-- .element: class="fragment" data-fragment-index="1" -->

- This way, we avoid redundancy <!-- .element: class="fragment" data-fragment-index="2" -->

<!-- slide -->

## Principles

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
