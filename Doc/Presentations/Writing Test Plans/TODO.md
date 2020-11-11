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

## A Test plan document

- *what* we will test, and
- *why* we will test that <!-- .element: class="fragment" data-fragment-index="1" -->
- in functional terms <!-- .element: class="fragment" data-fragment-index="2" -->

<!-- slide -->

## Test cases

- Test case steps are put in code <!-- .element: class="fragment" data-fragment-index="1" -->

- This way, we avoid redundancy <!-- .element: class="fragment" data-fragment-index="2" -->

<!-- slide -->

## Test analysis

State which will affect the outcome of test execution

- Input parameters  <!-- .element: class="fragment" data-fragment-index="1" -->

- Initial state <!-- .element: class="fragment" data-fragment-index="2" -->

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
